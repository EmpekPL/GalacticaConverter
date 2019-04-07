using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galactica_Converter
{
    public static class Engine
    {
        public static decimal calculate(int from, int to, decimal value, int switchIndicator)
        {
            if (switchIndicator == 0) // 0: convert from space to earth units 
                                      // 1: from earth to space units  
            {
                switch (from)
                {
                    case 0: //Light-second

                        switch (to)
                        {

                            case 0: // metre
                                return value * (decimal)299792543.55986;
                            case 1: // kilometre
                                return value * (decimal)299792.54355986;
                            case 2: // Nautical mile
                                return value * (decimal)161875.08244295;
                            default:
                                return (decimal)-1.00;

                        }

                    case 1: //Light-minute

                        switch (to)
                        {

                            case 0: // metre
                                return value * (decimal)17987552613.591;
                            case 1: // kilometre
                                return value * (decimal)17987552.613591;
                            case 2: // Nautical mile
                                return value * (decimal)9712504.946577;
                            default:
                                return (decimal)-1.00;

                        }
                    case 2: //Astronomical unit

                        switch (to)
                        {

                            case 0: // metre
                                return value * (decimal)149597806297.77;
                            case 1: // kilometre
                                return value * (decimal)149597806.29777;
                            case 2: // Nautical mile
                                return value * (decimal)80776382.695124;
                            default:
                                return (decimal)-1.00;
                        }

                    case 3: // Light-year

                        switch (to)
                        {

                            case 0: // metre
                                return value * (decimal)9.4605589298216E+15;
                            case 1: // kilometre
                                return value * (decimal)9460558929821.6;
                            case 2: // mila morska
                                return value * (decimal)161875.08244295;
                            default:
                                return (decimal)-1.00;

                        }
                    case 4: // parsec

                        switch (to)
                        {

                            case 0: // metre
                                return value * (decimal)30856769049426 * 1000;
                            case 1: // kilometre
                                return value * (decimal)30856769049426;
                            case 2: // Nautical mile
                                return value * (decimal)16661328445621;
                            default:
                                return (decimal)-1.00;

                        }


                }
            }
            else // 1: convert from earth to space units
            {
                switch (from)
                {
                    case 0: //metre
                        switch (to)
                        {
                            case 0: //Light-second
                                return value / (decimal)299792543.55986;
                            case 1: // Light-minute
                                return value / (decimal)17987552613.591;
                            case 2: // Astronomical unit
                                return value / (decimal)149597806297.77;
                            case 3: // Light-year
                                return value / (decimal)9.4605589298216E+15;
                            case 4: //parsec
                                return value / (30856769049426 * 1000);
                            default:
                                return (decimal)-1.00;
                        }
                    case 1:
                        switch (to)
                        { // kilomentre
                            case 0: // Light-second
                                return value / (decimal)299792.54355986;
                            case 1: // Light-minute
                                return value / (decimal)17987552.613591;
                            case 2: // Astronomical unit
                                return value / (decimal)149597806.29777;
                            case 3: // Light-year
                                return value / (decimal)9460558929821.6;
                            case 4: //parsec
                                return value / 30856769049426;
                            default:
                                return (decimal)-1.00;
                        }
                    case 2: // Nautical mile
                        switch (to)
                        {
                            case 0: // Light-second
                                return value / (decimal)9712504.946577;
                            case 1: // Light-minute
                                return value / (decimal)9712504.946577;
                            case 2: // Astronomical unit
                                return value / (decimal)80776382.695124;
                            case 3: // Light-year
                                return value / (decimal)161875.08244295;
                            case 4: // parsec
                                return value / 16661328445621;
                            default:
                                return (decimal)-1.00;
                        }
                    default:
                        return (decimal)-1.00;
                }
                
            }
            return (decimal)-1.00;




        }
           


        }

    }

