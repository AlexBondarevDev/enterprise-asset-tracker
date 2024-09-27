using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace EnterpriseAssetTracker.Scripts
{
    class WordHelper
    {
        private FileInfo _fileInfo;
        private Word.Application _app;
        private Word.Document _document;

        public WordHelper(string fileName)
        {
            if (File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
                _app = new Word.Application();
                _document = _app.Documents.Open(_fileInfo.FullName);
            }
            else
            {
                throw new ArgumentException("Шаблон отчёта не найден. Сформировать отчёт невозможно. Обратитесь к администратору.");
            }
        }

        internal bool Process(Dictionary<string, string> items, string path)
        {
            try
            {
                Object missing = Type.Missing;
                foreach (var item in items)
                {
                    Word.Find find = _app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(
                        FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing, Replace: replace);
                }

                _document.SaveAs2(path);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        internal void InsertTable(DataTable dataTable, int tableIndex)
        {
            Word.Table table = _document.Tables[tableIndex];
            int rowCount = table.Rows.Count;

            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    table.Cell(rowCount, i + 1).Range.Text = row[i].ToString();
                }

                if (rowCount < dataTable.Rows.Count)
                {
                    table.Rows.Add();
                    rowCount++;
                }
            }
            _document.Save();
        }

        public void SaveAndClose(string path)
        {
            try
            {
                _document.SaveAs2(path);
                _document.Close(false);
                _app.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении и закрытии документа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ReleaseObject(_document);
                ReleaseObject(_app);
            }
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show($"Ошибка при освобождении объекта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}