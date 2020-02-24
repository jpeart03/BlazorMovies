using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using BlazorMovies.Client.Helpers;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        [Inject]
        IJSRuntime js { get; set; }

        [CascadingParameter]
        public AppState AppState { get; set; }

        private List<Movie> movies;
        private int currentCount = 0;
        private static int currentCountStatic = 0;

        [JSInvokable]
        public async Task IncrementCount()
        {
            currentCount++;
            currentCountStatic++;
            singleton.Value = currentCount;
            transient.Value = currentCount;
            await js.InvokeVoidAsync("dotnetStaticInvocation");
        }

        private async Task IncrementCountJavascript()
        {
            await js.InvokeVoidAsync("dotnetInstanceInvocation", DotNetObjectReference.Create(this));
        }

        protected override void OnInitialized()
        {
            movies = new List<Movie>()
            {
            new Movie(){Title = "Once Upon a Time in Hollywood", ReleaseDate= new DateTime(2019, 12, 01)},
            new Movie(){Title = "Sonic", ReleaseDate= new DateTime(2020, 02, 14)},
        };
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }
    }
}
