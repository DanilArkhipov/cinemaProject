using System.Runtime.CompilerServices;
using LinqToDB.Configuration;
using LinqToDB.Data;

namespace Model
{
    
}
public class AppDataConnection: DataConnection
{
    public AppDataConnection(LinqToDbConnectionOptions<AppDataConnection> options)
        : base(options)
    {

    }
}