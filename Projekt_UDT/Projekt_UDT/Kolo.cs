using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Kolo : INullable
{
    private double m_r; //promien
    private double m_x, m_y; //współrzedne srodka

    public Kolo(double r, double x, double y)
    {
        m_r = r;
        m_x = x;
        m_y = y;
        m_Null = false;
    }

    public Kolo(bool nothing)
    {
        m_r = m_x = m_y = 0;
        m_Null = true;
    }

    public override string ToString()
    {
        return "Koło o promieniu " + m_r.ToString() 
                + " i środku w punkcie ( " + m_x.ToString() + " ,  "
                + m_y.ToString() + " )";
    }

    public bool IsNull
    {
        get
        {
            return m_Null;
        }
    }

    public static Kolo Null
    {
        get
        {
            Kolo h = new Kolo();
            h.m_Null = true;
            return h;
        }
    }

    public static Kolo Parse(SqlString s)
    {
        string value = s.Value;
        if (s.IsNull)
            return Null;

        if (s.Value.Split(".".ToCharArray()).Length > 1) throw new ArgumentException("Użyj przecinków zamiast kropek");
        string[] dane = s.Value.Split(" ".ToCharArray());
        if (dane.Length < 3) throw new ArgumentException("Za mała ilość argumentów");

        double r = double.Parse(dane[0]);
        double x = double.Parse(dane[1]);
        double y = double.Parse(dane[2]);

        if (r <=0) throw new ArgumentException("Podano nieprawidłową wartość promienia!");

        return new Kolo (r, x, y);
       }

    public double Pole()
    {
        return Math.Round(m_r * m_r * Math.PI, 3);
    }

    public double Obwod()
    {
        return Math.Round(2 * m_r * Math.PI, 3);
    }

    public bool CzyPunktNalezyDoKola(double x, double y)
    {
        double diff = Math.Sqrt( (m_x - x)*(m_x - x) + (m_y - y)*(m_y - y) );
        return m_r > diff;
    }

    // Private member
    private bool m_Null;
}


