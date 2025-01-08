using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Calculator
    {

        private async Task<int> CalculateApac()
        {
            await Task.Delay(15000);
            return 1;
        }

        private async Task<int> CalculateEu()
        {
            await Task.Delay(2000);
            return 2;
        }

        private async Task<int> CalculateUs()
        {
            await Task.Delay(4000);
            return 3;
        }

        public async Task<int> Calculate()
        {
            var apac = CalculateApac();
            var eu = CalculateEu();
            var us = CalculateUs();

            // Wait for all tasks to complete
            var results = await Task.WhenAll(apac, eu, us);

            // Sum the results
            return results[0] + results[1] + results[2];
        }
    }
}
