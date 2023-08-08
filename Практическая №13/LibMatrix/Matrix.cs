using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibMatrix
{
    public class Matrix<T>
    {
        private T[,] _items;
        private int _rows, _columns;

        /// <summary>
        /// Конструктор класса Matrix
        /// </summary>
        /// <param name="rowCount">Кол-во строк</param>
        /// <param name="columnCount">Кол-во столбцов</param>
        /// <param name="extension">Расширение</param>
        public Matrix(int rowCount, int columnCount, string extension = ".matrix")
        {
            _items = new T[rowCount, columnCount];
            Extension = extension;
        }

        /// <summary>
        /// Расширение для сохраняемого файла
        /// </summary>
        public string Extension { get; private set; }

        /// <summary>
        /// Индексатор класса Matrix
        /// </summary>
        /// <param name="row">Строки</param>
        /// <param name="column">Столбцы</param>
        /// <returns>Значение из двумерного массива _items</returns>
        public T this[int row, int column]
        {
            get { return _items[row, column]; }
            set { _items[row, column] = value; }
        }
        /// <summary>
        /// Сбрасывает значение полей и массива в значение по умолчанию
        /// </summary>
        public void DefaultInit()
        {
            _items = default;
            _rows = default;
            _columns = default;
        }
        /// <summary>
        /// Свойство поля Rows
        /// </summary>
        public int Rows
        {
            get => _rows; // получение значения из поля _rows
            private set // установка значения для поля _rows
            {
                if(value == _rows)
                {
                    return;
                }
                _rows = value;
            }
        }
        /// <summary>
        /// Свойство поля Columns
        /// </summary>
        public int Columns
        {
            get => _columns; // получение значения из поля _columns
            private set // установка значения для поля _columns
            {
                if(value == _columns)
                {
                    return;
                }
                _columns = value;
            }
        }
        /// <summary>
        /// Добавление значения в двумерный массив _items
        /// </summary>
        /// <param name="items">Значения с массива</param>
        public void Add(T[,] items)
        {
            _rows = items.GetLength(0);
            _columns = items.GetLength(1);
            _items = new T[_rows, _columns];
            for (int i = 0; i < items.GetLength(0); i++)
            {
                for (int j = 0; j < items.GetLength(1); j++)
                {
                    _items[i, j] = items[i, j];
                }
            }
        }

        private static readonly BinaryFormatter _formatter = new BinaryFormatter();

        public void Save(string path)
        {
            BinaryFormatter formatter = new();
            using (FileStream stream = new(path, FileMode.Create))
            {
                formatter.Serialize(stream, _items);
            }
        }


        public void Open(string path)
        {
            BinaryFormatter formatter = new();
            using (FileStream stream = new(path, FileMode.Open))
            {
                _items = formatter.Deserialize(stream) as T[,];
            }
        }


        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < _items.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < _items.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < _items.GetLength(1); j++)
                {
                    row[j] = _items[i, j];
                }

                res.Rows.Add(row);
            }
            return res;
        }
    }
    public static class VisualArray
    {
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
    }
}
