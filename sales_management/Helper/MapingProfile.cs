using AutoMapper;
using sales_management.Models;
using sales_management.ModelView;

namespace sales_management.Helper
{
    public class MapingProfile:Profile
    {
      public  MapingProfile()
        {
            CreateMap<CustomerType, CustomerTypeModelView>()
                .ReverseMap();

            CreateMap<CustomerModelView, Customer>()
               .ReverseMap();

            
            CreateMap<invoice,invoicesModelView >()
            .ForSourceMember(source => source.Total, opt => opt.DoNotValidate())
              .ReverseMap();

            CreateMap<Car,ProductToinvoiceModelView >()
             .ReverseMap();

            CreateMap<Company_infoModelView, Company_info>()
                .ForSourceMember(source => source.imagefile, opt => opt.DoNotValidate())
              .ReverseMap();

        }
    }
}
