using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bit706_as2
{
    public class DataIO : ParentForm
    {
        public static void RestoreData()
        {
            if (File.Exists("objects.bin"))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("objects.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                accountsController.accounts = (List<Account>)formatter.Deserialize(stream);
                customerController.customerList = (List<Customer>)formatter.Deserialize(stream);
                CustomerData.Set((CustomerData)formatter.Deserialize(stream));
                AccountData.Set((AccountData)formatter.Deserialize(stream));
                stream.Close();
            }
        }

        public static void WriteData()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("objects.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, accountsController.accounts);
            formatter.Serialize(stream, customerController.customerList);
            formatter.Serialize(stream, CustomerData.Get());
            formatter.Serialize(stream, AccountData.Get());
            stream.Close();
        }
    }
}
