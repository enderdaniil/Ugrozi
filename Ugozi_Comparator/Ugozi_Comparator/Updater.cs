using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.IO;

namespace Ugozi_Comparator
{
    public class Updater
    {
        private ObservableCollection<FullRecord> newFullRecords = new ObservableCollection<FullRecord>();
        private ObservableCollection<FullRecord> difference = new ObservableCollection<FullRecord>();

        public static bool UpdateInformation()
        {
            try
            {
                RecourceHandler.copyPath = Directory.GetCurrentDirectory() + "'\'copy'\'thrlist.xlsx";
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("У вас почему-то нет доступа к файлам (^人^)");
                throw;
            }

            try
            {
                new WebClient().DownloadFile("https://bdu.fstec.ru/files/documents/thrlist.xlsx", RecourceHandler.copyPathHandler);
            }
            catch (WebException)
            {
                MessageBox.Show("Ой, Ой, у вас какие-то проблемы с Интернетом...");
                return false;
            }
            catch (NoFileException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Хмм, проблема с файлами...");
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то внутри пошло не так... Походу разраб криворукий ;)");
                return false;
            }

            File.Delete(RecourceHandler.originalPath);

            ObservableCollection<FullRecord> localfullRecords = RecourceHandler.fullRecords;
            ObservableCollection<FullRecord> localNewRecords = Parser.FillFullCollection(RecourceHandler.copyPath);

            return true;
        }



        private class NoFileException : Exception
        {
            public override string Message => "Почему то пропал файл...";
        }
    }
}
