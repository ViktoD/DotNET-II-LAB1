using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace Lab1
{
    internal class Database
    {
        public static async Task Main(string[] args)
        {
           SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-OUM80I2\\SQLEXPRESS01;Database=Library;Integrated Security=true ");
           await sqlConnection.OpenAsync();

            SqlCommand command = new SqlCommand();

            command.Connection = sqlConnection;
            command.CommandText = "SELECT Readers.Surname, Readers.Name, Readers.PatronymicName, Readers.Address, Readers.Phone, Readers.DateBirth, Tickets.ID, Books.Author, Books.Name as book, InfoBooks.DateTakeBook, InfoBooks.DateReturnBook, Books.Price  FROM Books INNER JOIN InfoBooks ON Books.ID = InfoBooks.BookID INNER JOIN Tickets ON InfoBooks.TicketID = Tickets.ID INNER JOIN Readers ON Tickets.ReaderID = Readers.ID ORDER BY Readers.Surname, Readers.Name, Readers.PatronymicName";


            SqlDataReader dataReader = await command.ExecuteReaderAsync();

            WriteLine("SurnameReader\tNameReader\tPatronymicName\tAddress\tPhone\tBirthday\tTicketID\tAuthor\tNameBook\tDateTakeBook\tDateReturnBook\tPrice Book");
            
            while (await dataReader.ReadAsync())
            {

                WriteLine($"{dataReader["Surname"]}\t{dataReader["Name"]}\t{dataReader["PatronymicName"]}\t{dataReader["Address"]}\t{dataReader["Phone"]}\t{dataReader["DateBirth"]}\t{dataReader["ID"]}\t{dataReader["Author"]}\t{dataReader["book"]}\t{dataReader["DateTakeBook"]}\t{dataReader["DateReturnBook"]}\t{dataReader["Price"]}");
            }
           await sqlConnection.CloseAsync();
        }
    }
}
