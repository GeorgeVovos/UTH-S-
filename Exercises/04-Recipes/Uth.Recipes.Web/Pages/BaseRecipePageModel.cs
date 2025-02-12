﻿using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Uth.Recipes.Web.ViewModels;

namespace Uth.Recipes.Web.Pages
{
    public abstract class BaseRecipePageModel : PageModel
    {
        protected readonly ImageViewModel NoImageData;
        protected readonly ImageViewModel CongratulationsImageData;

        protected BaseRecipePageModel()
        {
            NoImageData = new ImageViewModel { Data = System.IO.File.ReadAllBytes(Path.Combine("wwwroot", "images", "nodata.jpg")) };
            CongratulationsImageData = new ImageViewModel { Data = System.IO.File.ReadAllBytes(Path.Combine("wwwroot", "images", "Congradulations.jpg")) };
        }

        protected void SetEmptyImagesIfNecessary(RecipeViewModel recipe)
        {
            if ((!recipe.Images?.Any() ?? false))
                recipe.Images.Add(NoImageData);

            if (recipe.Steps == null)
                return;

            foreach (var step in recipe.Steps)
                if ((!step.Images?.Any() ?? false))
                    step.Images.Add(NoImageData);
        }
    }
}