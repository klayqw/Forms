using Moq;
using Steam.Data;
using Steam.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest;

public class Group
{
    [Fact]
    public void GetById_SendNegativeId_ThrowArgumentOutOfRangeException()
    {
        var sqldbcontextmock = new Mock<SteamDBContext>();
        var gameservice = new GroupService(null);

        Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
        {
            await gameservice.GetById(-1);
        });
    }
    [Fact]
    public void DeleteFromLibary_SendNegativeId_ThrowArgumentOutOfRangeException()
    {
        var sqldbcontextmock = new Mock<SteamDBContext>();
        var gameservice = new GroupService(null);

        Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
        {
            await gameservice.DeleteFromLibary(-1, "test");
        });
    }

    [Fact]
    public void Update_SendNegativeId_ThrowArgumentOutOfRangeException()
    {
        var sqldbcontextmock = new Mock<SteamDBContext>();
        var gameservice = new GroupService(null);

        Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
        {
            await gameservice.Update(-1, null);
        });
    }
}
