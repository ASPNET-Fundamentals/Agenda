using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Entity;

namespace Agenda.BLL
{
    public class MemoryExampleBusiness : IExampleBusiness, IDisposable
    {
        private List<Example> lstExample;
        public void Dispose()
        {
        }

        public MemoryExampleBusiness(List<Example> lstExample)
        {            
            this.lstExample = lstExample;
        }

        public Example GetExampleByID(Example example)
        {
            return this.lstExample.Single(p => p.id.Equals(example.id));
        }

        public List<Example> GetListExampleByFilter(ExampleFilter exampleFilter)
        {
            if (!string.IsNullOrEmpty(exampleFilter.value))
            {
                return this.lstExample.FindAll(p => p.value.Contains(exampleFilter.value)).OrderBy(p => p.id).ToList();                
            }
            else 
            {
                return this.lstExample.OrderBy(p => p.id).ToList();
            }
        }

        public Example Insert(Example example)
        {            
            int max = this.lstExample.OrderByDescending(x => x.id).First().id.Value;
            example.id = (max + 1);
            this.lstExample.Add(example);

            return example;
        }

        public void Update(Example example)
        {
            this.lstExample.Remove(example);
            this.lstExample.Add(example);
        }

        public void Delete(Example example)
        {
            Example exampleDelete = this.lstExample.Find(p => p.id.Equals(example.id));
            if (example != null)
            { 
                this.lstExample.Remove(exampleDelete);
            }
        }

    }
}
