using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Trojkat : INullable
{
    private double m_ax, m_ay; //wierzchołek A
    private double m_bx, m_by; //wierzchołek B
    private double m_cx, m_cy; //wierzchołek C

    public Trojkat(double ax, double ay, double bx, double by, double cx, double cy)
    {
        m_ax = ax;
        m_ay = ay;
        m_bx = bx;
        m_by = by;
        m_cx = cx;
        m_cy = cy;
        m_Null = false;
    }

    public Trojkat(bool nothing)
    {
        m_ax = m_ay = m_bx = m_by = m_cx = m_cy = 0;
        m_Null = true;
    }

    public override string ToString()
    {
        return "Trójkąt o wierzchołkach A( " + m_ax.ToString() + " , " + m_ay.ToString() 
                                 + " ), B( " + m_bx.ToString() + " , " + m_by.ToString()
                                 + " ), C( " + m_cx.ToString() + " , " + m_cy.ToString() + " )";
    }

    public bool IsNull
    {
        get
        {
            return m_Null;
        }
    }

    public static Trojkat Null
    {
        get
        {
            Trojkat h = new Trojkat();
            h.m_Null = true;
            return h;
        }
    }

    public static Trojkat Parse(SqlString s)
    {
        string value = s.Value;
        if (s.IsNull)
            return Null;

        if (s.Value.Split(".".ToCharArray()).Length > 1) throw new ArgumentException("Użyj przecinków zamiast kropek");
        string[] dane = s.Value.Split(" ".ToCharArray());
        if (dane.Length < 6) throw new ArgumentException("Za mała ilość argumentów");

        double ax = double.Parse(dane[0]);
        double ay = double.Parse(dane[1]);
        double bx = double.Parse(dane[2]);
        double by = double.Parse(dane[3]);
        double cx = double.Parse(dane[4]);
        double cy = double.Parse(dane[5]);

        Trojkat tmp = new Trojkat(ax, ay, bx, by, cx, cy);

        if (!tmp.SprawdzPunkty()) throw new ArgumentException("Podane punkty nie tworzą trójkąta");

        return tmp;
       }

    public bool SprawdzPunkty()
    {
        double[] boki = PoliczBoki();
        double a = boki[0], b = boki[1], c = boki[2];
        if ( ( (a+b) > c ) && ( (a+c) > b ) && ( (b+c) > a ))
            return true;
        else return false;
    }
    public double Pole()
    {
        double[] boki = PoliczBoki();
        double a = boki[0], b = boki[1], c = boki[2];
        double p = 0.5 * (a + b + c);
        return Math.Round(Math.Sqrt( p*(p-a)*(p-b)*(p-c) ) , 3);
    }

    public double Obwod()
    {
        double[] boki = PoliczBoki();
        double a = boki[0], b = boki[1], c = boki[2];
        return Math.Round(a + b + c, 3);
    }

    private double[] PoliczBoki()
    {
        double[] boki = new double[3];

        boki[0] = Math.Sqrt((m_ax - m_bx) * (m_ax - m_bx) + (m_ay - m_by) * (m_ay - m_by));
        boki[1] = Math.Sqrt((m_ax - m_cx) * (m_ax - m_cx) + (m_ay - m_cy) * (m_ay - m_cy));
        boki[2] = Math.Sqrt((m_cx - m_bx) * (m_cx - m_bx) + (m_cy - m_by) * (m_cy - m_by));

        return boki;
    }

    public String DlugosciBokow()
    {
        double[] boki = PoliczBoki();
        return "Dłogości boków wynoszą: " + boki[0].ToString() + ", " + boki[1].ToString() + ", " + boki[2].ToString();
    }

    // Private member
    private bool m_Null;
}


