#r "packages/SQLProvider/lib/net451/FSharp.Data.SQLProvider.dll"
open FSharp.Data.Sql

let [<Literal>] dbVendor = Common.DatabaseProviderTypes.MSSQLSERVER
let [<Literal>] connString = """Data Source=(localdb)\ProjectsV13;Initial Catalog=SFA.DAS.Forecasting.Database;Integrated Security=True;Pooling=False;Connect Timeout=30"""

let [<Literal>] useOptTypes  = true

type sql =
    SqlDataProvider<
        dbVendor,
        connString>

let ctx = sql.GetDataContext()

let sum = 
    ctx.Dbo.Commitment
    |> Seq.where (fun f -> f.EmployerAccountId = 12345L )
    |> Seq.sumBy (fun f -> f.MonthlyInstallment )

printfn "%f" sum