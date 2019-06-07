using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Rownoleglobok : INullable
{
    private double m_ax, m_ay; //wierzchołek A
    private double m_bx, m_by; //wierzchołek B
    private double m_cx, m_cy; //wierzchołek C
    private double m_dx, m_dy; //wierzchołek D

    public Rownoleglobok(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy)
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

    public Rownoleglobok(bool nothing)
    {
        m_ax = m_ay = m_bx = m_by = m_cx = m_cy = m_dx = m_dy = 0;
        m_Null = true;
    }

    public override string ToString()
    {
        return "Równoległobok o wierzchołkach A( " + m_ax.ToString() + " , " + m_ay.ToString() 
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

    public static Rownoleglobok Null
    {
        get
        {
            Rownoleglobok h = new Rownoleglobok();
            h.m_Null = true;
            return h;
        }
    }

    public static Rownoleglobok Parse(SqlString s)
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

        Rownoleglobok tmp = new Rownoleglobok(ax, ay, bx, by, cx, cy, dx, dy);

        if (!tmp.SprawdzPunkty()) throw new ArgumentException("Podane punkty nie tworzą równolegloboku - "
            + "pamiętaj, podaj wartości z kolejnych wierzchołków.");

        return tmp;
    }

    public bool SprawdzPunkty()
    {
        double[] boki = PoliczBoki();
        double a = boki[0], b = boki[1], c = boki[2], d = boki[3];
        return (a == c) && (b == d);
    }

    public double Pole()
    {
        double h = PoliczWysokosc();
        double a = PoliczBoki()[0];
        return Math.Round(a * h, 3);
    }

    public double Obwod()
    {
        double[] boki = PoliczBoki();
        double a = boki[0], b = boki[1];
        return Math.Round(2 * a + 2 * b, 3);
    }

    private double[] PoliczBoki()
    {
        double[] boki = new double[4];

        boki[0] = Math.Sqrt((m_ax - m_bx) * (m_ax - m_bx) + (m_ay - m_by) * (m_ay - m_by)); //AB
        boki[1] = Math.Sqrt((m_cx - m_bx) * (m_cx - m_bx) + (m_cy - m_by) * (m_cy - m_by)); //BC
        boki[2] = Math.Sqrt((m_cx - m_dx) * (m_cx - m_dx) + (m_cy - m_dy) * (m_cy - m_dy)); //CD
        boki[3] = Math.Sqrt((m_ax - m_dx) * (m_ax - m_dx) + (m_ay - m_dy) * (m_ay - m_dy)); //AD

        return boki;
    }

    private double PoliczWysokosc()
    {
        double hx = m_ax, hy = m_dy;
        return Math.Sqrt((hx - m_dx) * (hx - m_dx) + (hy - m_dy) * (hy - m_dy));
    }

    public String DlugosciBokow()
    {
        double[] boki = PoliczBoki();
        return "Dłogości boków wynoszą: " + boki[0].ToString() + ", " + boki[1].ToString()
            + ", " + boki[2].ToString() + " i " + boki[3].ToString();
    }

    // Private member
    private bool m_Null;
}


