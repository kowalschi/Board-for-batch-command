using System;

namespace WinFormsApp1
{


    public class HistoryListClasa : IEquatable<HistoryListClasa>, IComparable<HistoryListClasa>
    {
        private string pathHistory;
        private string dataHistory;
        public HistoryListClasa() { }
        public HistoryListClasa(string pathForHistory, string DataForHistory)
        {
            PathInHistory = pathForHistory;
            DataInHistory = DataForHistory;
        }

        public string PathInHistory
        {
            get { return pathHistory; }
            set { pathHistory = value; }

        }

        public string DataInHistory
        {
            get { return dataHistory; }
            set { dataHistory = value; }
        }
        public int CompareTo(HistoryListClasa b)
        {
            //return this.DataInHistory.CompareTo(b.DataInHistory);// sort normal
            return b.DataInHistory.CompareTo(this.DataInHistory); // sort descending cu ultima intrare sa afiseze prima
        }

        // public string PartName { get; set; }

        // public int PartId { get; set; }

        public override string ToString()
        {
            return "data: " + dataHistory + "   Path: " + pathHistory;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            HistoryListClasa objAsPart = obj as HistoryListClasa;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            int hashpathHistory = pathHistory == null ? 0 : pathHistory.GetHashCode();
            return hashpathHistory;
        }
        public bool Equals(HistoryListClasa other)
        {
            if (other == null) return false;
            return (this.pathHistory.Equals(other.pathHistory));
        }
        // Should also override == and != operators.

        // class Comparer : IEqualityComparer<HistoryListClasa> {
        // public bool Equals(HistoryListClasa x, HistoryListClasa y) {
        //     return x.PathInHistory == y.PathInHistory; // based on variable i
        // }
        // public int GetHashCode(HistoryListClasa obj) {
        //     return obj.PathInHistory.GetHashCode(); // hashcode of variable to compare
        // }

    }




    // public class Part : IEquatable<Part>
    //     {
    //         public string PartName { get; set; }

    //         public int PartId { get; set; }

    //         public override string ToString()
    //         {
    //             return "ID: " + PartId + "   Name: " + PartName;
    //         }
    //         public override bool Equals(object obj)
    //         {
    //             if (obj == null) return false;
    //             Part objAsPart = obj as Part;
    //             if (objAsPart == null) return false;
    //             else return Equals(objAsPart);
    //         }
    //         public override int GetHashCode()
    //         {
    //             return PartId;
    //         }
    //         public bool Equals(Part other)
    //         {
    //             if (other == null) return false;
    //             return (this.PartId.Equals(other.PartId));
    //         }
    //     // Should also override == and != operators.
    //     }









    //    public string pathHistory { get; set; }
    // public string dataHistory { get; set; }

    // public string Name { get; set; }
    // public int Code { get; set; }

    //    public bool Equals(HistoryListClasa other)
    //    {

    //        //Check whether the compared object is null.
    //        if (Object.ReferenceEquals(other, null)) return false;

    //        //Check whether the compared object references the same data.
    //        if (Object.ReferenceEquals(this, other)) return true;

    //        //Check whether the products' properties are equal.
    //        //return dataHistory.Equals(other.dataHistory) && pathHistory.Equals(other.pathHistory);
    //        return pathHistory.Equals(other.pathHistory);
    //}

    // If Equals() returns true for a pair of objects
    // then GetHashdataHistory() must return the same value for these objects.

    // public override int GetHashdataHistory()
    // {

    //     //Get hash dataHistory for the pathHistory field if it is not null.
    //     int hashProductpathHistory = pathHistory == null ? 0 : pathHistory.GetHashdataHistory();

    //     //Get hash dataHistory for the dataHistory field.
    //     int hashProductdataHistory = dataHistory.GetHashdataHistory();

    //     //Calculate the hash dataHistory for the product.
    //     return hashProductpathHistory ^ hashProductdataHistory;
    // }










    // }







    // public class Person : INotifyPropertyChanged
    // {
    //     public Person(string n, string name, string address)
    //     {
    //         _number = n;
    //         _name = name;
    //         _address = address;
    //     }

    //     public string Number
    //     {
    //         get { return _number; }
    //         set
    //         {
    //             if (_number != value)
    //             {
    //                 _number = value;
    //                 this.NotifyPropertyChanged("Number");
    //             }
    //         }
    //     }

    //     public string Name
    //     {
    //         get { return _name; }
    //         set
    //         {
    //             if (_name != value)
    //             {
    //                 _name = value;
    //                 this.NotifyPropertyChanged("Name");
    //             }
    //         }
    //     }

    //     public string Address
    //     {
    //         get { return _address; }
    //         set
    //         {
    //             if (_address != value)
    //             {
    //                 _address = value;
    //                 this.NotifyPropertyChanged("Address");
    //             }
    //         }
    //     }

    //     private string _number;
    //     private string _name;
    //     private string _address;

    //     public event PropertyChangedEventHandler PropertyChanged;

    //     private void NotifyPropertyChanged(string name)
    //     {
    //         if (PropertyChanged != null)
    //             PropertyChanged(this, new PropertyChangedEventArgs(name));
    //     }
    // }
}