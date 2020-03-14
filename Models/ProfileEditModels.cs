using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC_WH.Models
{
    public class ProfileEditModels
    {
        [Display(Name = "Kiiratas")]
        public string TextToHtml { get; set; }
    }

    public class JobEnum : IEnumerable<SelectListItem>
    {
        List<SelectListItem> sltList = new List<System.Web.Mvc.SelectListItem>();
        SelectListItem slt = new SelectListItem() { Text = "ada", Value = "fsdfs" };

        
        

        public IEnumerator<SelectListItem> GetEnumerator()
        {
            sltList.Add(slt);

            return sltList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }


    public class SelectListModel
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }


   


}