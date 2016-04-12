using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Attribute
    {
        private string NameAttr;
        private int Value;


        public Attribute() { }


        public Attribute(String n, int v)
        {
            this.NameAttr = n;
            this.Value = v;
        }


        public string getNameAttr()
        {
            return this.NameAttr;
        }


        public void setNameAttr(string s)
        {
            this.NameAttr = s;
        }


        public int getValue()
        {
            return this.Value;
        }
        public void setValue(int v)
        {
            this.Value = v;
        }


        public void toString()
        {
            Console.WriteLine("Name Attribute:" + NameAttr + "Value:" + Value);
        }

        //questo metodo (invocato su un attributo) calcola la somma del suo valore 
        //con i valori degli attributi dello stesso tipo presenti nella lista passata come parametro.        
        public int calcAttributo(List<Attribute> l)
        {
            int somma = 0;

            String first_Name = this.getNameAttr();

            somma = (somma + (Convert.ToInt16(this.getValue())));
            //Console.WriteLine("Valore "+this.getValue());
            for (int j = 1; j < l.Count; j++)
            {
                if (l[j].getNameAttr() == first_Name)
                {
                    somma = (somma + (Convert.ToInt16(l[j].getValue())));
                   // Console.WriteLine("Valore "+ l[j].getValue());
                }
            }


            return somma;
        }
    }

}
