using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lullo.Models.Recepies
{
    public class Recipies
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of the recipe is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ingredients are required")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Prepare instructions are required")]
        public string PrepareInstructions { get; set; }

        [Required(ErrorMessage = "The kind of kitchen is required")]
        public string Kitchens { get; set; }

        [Required(ErrorMessage = "What kind of course is required")]
        public string Course { get; set; }

        [Required(ErrorMessage = "The number of people are required")]
        [Range(1,10 )]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "The preparation time is required")]
        [Range(1, 180)]
        public int PreparationTime { get; set; }

    }

    public class Course
    {
        public int RecipeId { get; set; }
        public string CourseName { get; set; }

    }

    public class Kitchens
    {
        public int RecipeId { get; set; }
        public string KitchenName { get; set; }
    }
}