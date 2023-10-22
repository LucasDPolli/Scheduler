using AutoMapper;
using Scheduler.Data;

namespace Scheduler.Model.Mapper;

public static class MapperConfig
{
    public static AutoMapper.Mapper InitializeMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Schedule, Schedule_Table>().ReverseMap();
        });

        var mapper = new AutoMapper.Mapper(config);
        return mapper;
    }
}