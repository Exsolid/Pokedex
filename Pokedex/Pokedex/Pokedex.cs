using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedex
{
    public partial class FormPokedex : Form
    {
        private Backend _backendData;

        public FormPokedex()
        {
            InitializeComponent();

            _backendData = new Backend();

            _dataGridViewPokedex.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dataGridViewPokedex.MultiSelect = false;

            FillGridView();
        }

        private async void FillGridView()
        {

            await _backendData.ReadShallowData();
            Dictionary<string, List<PokemonData>> pokemon = _backendData.Pokemon;

            foreach (KeyValuePair<string, List<PokemonData>> pair in pokemon)
            {
                foreach (PokemonData data in pair.Value)
                {
                    int index = _dataGridViewPokedex.Rows.Add();
                    _dataGridViewPokedex.Rows[index].Cells[0].Value = data.Name;
                    _dataGridViewPokedex.Rows[index].Cells[1].Value = data.EntryNumber;
                    _dataGridViewPokedex.Rows[index].Cells[2].Value = pair.Key;
                }
            }
        }

        private void DataGridViewPokedex_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 1)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }
        }
    }
}
