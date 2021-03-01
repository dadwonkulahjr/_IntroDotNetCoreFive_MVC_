namespace DotNetCoreFive_MVC_Project.ViewModels
{
    public class EditCustomerViewModel : CustomerCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
