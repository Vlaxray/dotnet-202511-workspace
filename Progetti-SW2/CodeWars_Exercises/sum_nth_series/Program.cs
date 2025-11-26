using System;

public class NthSeries {
	
	public static string SeriesSum (int n) {
        double somma = 0.00f;
        for (int m=0; m < n; m++){
            somma += n*(1 + 1/(1+3*m));

            if(m==n-1){
                return String.Format("{0:0.00}",somma);
            }
        }
	}
}