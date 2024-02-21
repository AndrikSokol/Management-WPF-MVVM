using Inventory_managment.Data;
using Inventory_managment.DTO;
using Inventory_managment.Helpers;
using Inventory_managment.Model;
using Inventory_managment.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.ComponentModel;
using System.Windows;

namespace Inventory_managment.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly MissionService _missionService;

        private MissionDTO _missionDTO;

        private List<string> _filteredCodes;

        private List<Bottle> _bottle;
        private List<Pallet> _pallets;
        private List<Box> _boxes;

        private ApplicationDbContext _context;

        public MissionDTO MissionDTO
        {
            get { return _missionDTO; }
            set { _missionDTO = value; OnPropertyChanged(nameof(MissionDTO)); }
        }

        public List<Bottle> Bottles
        {
            get { return _bottle; }
            set { _bottle = value; OnPropertyChanged(nameof(Bottles)); }
        }

        public List<Box> Boxes
        {
            get { return _boxes; }
            set { _boxes = value; OnPropertyChanged(nameof(Boxes)); }
        }

        public List<Pallet> Pallets
        {
            get { return _pallets; }
            set { _pallets = value; OnPropertyChanged(nameof(Pallets)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public RelayCommand ImportCodesCommand => new RelayCommand(execute => ImportCodes());

        public RelayCommand CreateJsonFileCommand => new RelayCommand(execute => CreateJsonFile());


        public MainWindowViewModel()
        {
            _context = new ApplicationDbContext();
            _context.Database.EnsureCreated();

            ClearTableRows<Bottle>();
            ClearTableRows<Box>();
            ClearTableRows<Pallet>();

            _missionService = new MissionService();

            LoadMissionAsync();
        }

        private void ClearTableRows<T>() where T : class
        {
            var dbSet = _context.Set<T>();
            dbSet.RemoveRange(dbSet); // Removes all rows in the DbSet
            _context.Database.ExecuteSqlRaw($"DELETE FROM sqlite_sequence WHERE name='{nameof(T)}'");
            _context.SaveChanges();
        }

        private void CreateJsonFile()
        {
            MapJSON mapJSON = new MapJSON
            {
                ProductName = MissionDTO.Name,
                Gtin = MissionDTO.Gtin,
                BoxFormat = MissionDTO.BoxFormat,
                PalletFormat = MissionDTO.PalletFormat,
                Pallets = new List<PalletInfo>()
            };

            // Assuming you have a collection of Pallets
            foreach (var pallet in _context.Pallets)
            {
                PalletInfo palletInfo = new PalletInfo
                {
                    Id = pallet.Id,
                    Code = pallet.Code,
                    Boxes = (from box in _context.Boxes
                             where box.PalletId == pallet.Id
                             select new BoxInfo
                             {
                                 Id = box.Id,
                                 Code = box.Code,
                                 Bottles = (from bottle in _context.Bottles
                                            where bottle.BoxId == box.Id
                                            select new BottleInfo
                                            {
                                                Id = bottle.Id,
                                                Code = bottle.Code
                                            }).ToList()
                             }).ToList()
                };

                mapJSON.Pallets.Add(palletInfo);
            }

            JsonHelper.ExportMapJSON(mapJSON);

            MessageBox.Show("JSON file created successfully!");
        }

        private void ImportCodes()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Select a Text File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    var codes = FileHelper.ReadCodesFromFile(filePath);

                    var filteredCodes = codes
                        .Where(code => code.Contains(MissionDTO.Gtin))
                        .ToList();

                    _filteredCodes = filteredCodes;

                    CreatedTables();

                    MessageBox.Show("Codes imported successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error importing codes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private async void CreatedTables()
        {
            try
            {
                PalletViewModel pVM = new PalletViewModel(MissionDTO, _context);
                await pVM.CreatedPalletsAsync(_filteredCodes);

                BoxViewModel bVM = new BoxViewModel(MissionDTO, _context);
                await bVM.CreatedBoxesAsync(_filteredCodes);

                BottleViewModel bottleViewModel = new BottleViewModel(_context);

                await bottleViewModel.CreatedBottlesAsync(_filteredCodes, MissionDTO.BoxFormat);

                _bottle = await _context.Bottles.ToListAsync();

                OnPropertyChanged(nameof(Bottles));

                _boxes = await _context.Boxes.ToListAsync();

                OnPropertyChanged(nameof(Boxes));

                _pallets = await _context.Pallets.ToListAsync();

                OnPropertyChanged(nameof(Pallets));
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error processing filtered codes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void LoadMissionAsync()
        {
            MissionDTO mission = await _missionService.GetMissionAsync();

            if (mission != null)
            {
                MissionDTO = mission;
                OnPropertyChanged(nameof(MissionDTO));
            }
            else
            {
                MessageBox.Show("Error loading mission data");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
