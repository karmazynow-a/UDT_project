using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Prostokat : INullable
{
    private double m_ax, m_ay; //wierzchołek A
    private double m_bx, m_by; //wierzchołek B
    private double m_cx, m_cy; //wierzchołek C
    private double m_dx, m_dy; //wierzchołek D

    public Prostokat(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy)
    {
        m_ax = ax;
        m_ay = ay;
        m_bx = bx;
        m_by = by;
        m_cx = cx;
        m_cy = cy;
        m_dx = dx;
        m_dy = dy;
        m_Null = false;
    }

    public Prostokat(bool nothing)
    {
        m_ax = m_ay = m_bx = m_by = m_cx = m_cy = m_dx = m_dy = 0;
        m_Null = true;
    }

    public override string ToString()
    {
        return "Prostokąt o wierzchołkach A( " + m_ax.ToString() + " , " + m_ay.ToString() 
                                 + " ), B( " + m_bx.ToString() + " , " + m_by.ToString()
                                 + " ), C( " + m_cx.ToString() + " , " + m_cy.ToString()
                                  + " ), D( " + m_dx.ToString() + " , " + m_dy.ToString() + " )";
    }

    public bool IsNull
    {
        get
        {
            return m_Null;
        }
    }

    public static Prostokat Null
    {
        get
        {
            Prostokat h = new Prostokat();
            h.m_Null = true;
            return h;
        }
    }

    public static Prostokat Parse(SqlString s)
    {
        string value = s.Value;
        if (s.IsNull)
            return Null;

        if (s.Value.Split(".".ToCharArray()).Length > 1) throw new ArgumentException("Użyj przecinków zamiast kropek");
        string[] dane = s.Value.Split(" ".ToCharArray());
        if (dane.Length < 8) throw new ArgumentException("Za mała ilość argumentów");

        double ax = double.Parse(dane[0]);
        double ay = double.Parse(dane[1]);
        double bx = double.Parse(dane[2]);
        double by = double.Parse(dane[3]);
        double cx = double.Parse(dane[4]);
        double cy = double.Parse(dane[5]);
        double dx = double.Parse(dane[6]);
        double dy = double.Parse(dane[7]);

        Prostokat tmp = new Prostokat(ax, ay, bx, by, cx, cy, dx, dy);

        if (!tmp.SprawdzPunkty()) throw new ArgumentException("Podane punkty nie tworzą prostokąta - "
            + "pamiętaj, podaj wartości z kolejnych wierzchołków");

        return tmp;
       }

    public bool SprawdzPunkty()
    {
        double p1 = Math.Sqrt((m_ax - m_cx) * (m_ax - m_cx) + (m_ay - m_cy) * (m_ay - m_cy));
        double p2 = Math.Sqrt((m_bx - m_dx) * (m_bx - m_dx) + (m_by - m_dy) * (m_by - m_dy));
        return p1 == p2;
    }

    public double Pole()
    {
        double[] boki = PoliczBoki();
        double a = boki[0], b = boki[1];
        return Math.Round(a * b, 3);
    }

    public double Obwod()
    {
        double[] boki = PoliczBoki();
        double a = boki[0], b = boki[1];
        return Math.Round(2*a + 2*b, 3);
    }

    private double[] PoliczBoki()
    {
        double[] boki = new double[2];

        boki[0] = Math.Sqrt((m_ax - m_bx) * (m_ax - m_bx) + (m_ay - m_by) * (m_ay - m_by)); //AB i CD
        boki[1] = Math.Sqrt((m_cx - m_bx) * (m_cx - m_bx) + (m_cy - m_by) * (m_cy - m_by)); //BC i DA

        return boki;
    }

    public String DlugosciBokow()
    {
        double[] boki = PoliczBoki();
        return "Dłogości boków wynoszą: " + boki[0].ToString() + " i " + boki[1].ToString();
    }

    // Private member
    private bool m_Null;
}


