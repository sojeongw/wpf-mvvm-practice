using System.Collections.Generic;

namespace TRM_data_manager_wpf
{
    public interface ICalculations
    {
        List<string> Register { get; set; }

        double Add(double x, double y);
    }
}