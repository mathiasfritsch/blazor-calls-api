using blazorwasm_calls_MS_graph.Data;
using blazorwasm_calls_MS_graph.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace blazorwasm_calls_MS_graph.Pages
{
    public partial class FetchTestData 
    {
        [Inject]
        public ITestDataService TestDataService { get; set; }

        public Person TestData { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TestData = await TestDataService.GetData();
        }
    }
}
