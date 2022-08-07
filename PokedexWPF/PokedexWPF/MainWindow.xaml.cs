using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PokedexWPF.Logic;
using System.Windows.Media.Imaging;
using System.IO;

namespace PokedexWPF
{
    public partial class MainWindow : Window
    {
        private Backend _backendData;
        private BitmapImage _loadingBall;
        private List<PokemonData> _currentDexData;

        public MainWindow()
        {
            InitializeComponent();
            FillGridView();

            _currentDexData = new List<PokemonData>();
            _loadingBall = new BitmapImage(new Uri("pack://application:,,,/Assets/poke-ball.png"));

            FillBlank();
           }

        private void FillBlank()
        {
            TextBoxName.Text = "None Selected";
            TextBoxEntryID.Text = "None Selected";
            TextBoxTypes.Text = "None Selected";
            TextBoxHabitat.Text = "None Selected";
            TextBoxDescription.Text = "None Selected";
            ImageSprite.Source = _loadingBall;
        }
        
        private async void FillGridView()
        {
            if(_backendData == null)
            {
                _backendData = new Backend();
                await _backendData.ReadShallowData();
            }

            Dictionary<string, List<PokemonData>> pokemon = _backendData.Pokemon;
            
            foreach (string pokedex in pokemon.Keys.Distinct())
            {
                ComboBoxPokedexes.Items.Add("" + pokedex);
            }
            ComboBoxPokedexes.SelectedIndex = 0;
        }

        private async void SelectionChangedHandler(object sender, SelectionChangedEventArgs args)
        {
            if(_backendData == null)
            {
                _backendData = new Backend();
                await _backendData.ReadShallowData();
            }
            DataGridPokemon.Items.Clear();
            _currentDexData.Clear();

            var pokemon = _backendData.Pokemon.Where(p => p.Key.Equals(ComboBoxPokedexes.SelectedItem));

            foreach (KeyValuePair<string, List<PokemonData>> pair in pokemon)
            {
                foreach (PokemonData data in pair.Value)
                {
                    _currentDexData.Add(data);
                    DataGridPokemon.Items.Add(data);
                }
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void ButtonCloseClickHandler(object sender, RoutedEventArgs args)
        {
            this.Close();
        } 

        private void ButtonSearchClickHandler(object sender, RoutedEventArgs args)
        {
            if(TextBoxSearch.Text == null || TextBoxSearch.Text.Trim(' ').Equals(""))
            {
                DataGridPokemon.Items.Clear();
                foreach(PokemonData p in _currentDexData)
                {
                    DataGridPokemon.Items.Add(p);
                }
                return;
            }

            int index;
            bool isNumeric = int.TryParse(TextBoxSearch.Text.Trim(' '), out index);
            List<PokemonData> data = new List<PokemonData>();

            if (isNumeric)
            {
                data = _currentDexData.Where(p => p.EntryID.Equals(index)).ToList();
            }
            else
            {
                data = _currentDexData.Where(p => p.Name.Contains(TextBoxSearch.Text.Trim(' '))).ToList();
            }

            DataGridPokemon.Items.Clear();
            foreach (PokemonData p in data)
            {
                DataGridPokemon.Items.Add(p);
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                ButtonSearchClickHandler(null, null);
            }
        }

        private async void DataGridPokemonSelectionChangedHandler(object sender, SelectedCellsChangedEventArgs args)
        {
            if (args.AddedCells.Count != 0)
            {
                TextBoxTypes.Text = "Loading...";
                TextBoxHabitat.Text = "Loading...";
                TextBoxDescription.Text = "Loading...";
                ImageSprite.Source = _loadingBall;

                PokemonData data = (PokemonData) args.AddedCells[0].Item;
                TextBoxName.Text = data.Name;
                TextBoxEntryID.Text = data.EntryID.ToString();

                await _backendData.ReadPokemonDetails(data.Name);

                if(_backendData.LastReadDetails != null)
                {
                    if(_backendData.LastReadDetails.Types.Count() != 0)
                    {
                        TextBoxTypes.Text = "";
                        foreach (string type in _backendData.LastReadDetails.Types)
                        {
                            TextBoxTypes.Text += type + " ";
                        }
                    }
                    else
                    {
                        TextBoxTypes.Text = "Unknown";
                    }
                    TextBoxHabitat.Text = _backendData.LastReadDetails.Habitat != "" ? _backendData.LastReadDetails.Habitat : "Unknown";
                    TextBoxDescription.Text = _backendData.LastReadDetails.Description != "" ? _backendData.LastReadDetails.Description : "Unknown";
                    ImageSprite.Source = _backendData.LastReadDetails.Sprite;
                }
                else
                {
                    TextBoxTypes.Text = "Failed to read data.";
                    TextBoxHabitat.Text = "Failed to read data.";
                    TextBoxDescription.Text = "Failed to read data.";
                }
            }
            else
            {
                FillBlank();
            }
        }
    }
}
