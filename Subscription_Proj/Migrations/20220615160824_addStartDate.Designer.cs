// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Subscription_Proj.Models;

namespace Subscription_Proj.Migrations
{
    [DbContext(typeof(SubscriptionInfoContext))]
    [Migration("20220615160824_addStartDate")]
    partial class addStartDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Subscription_Proj.Models.SubscriptionInfo", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubPeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubscriptionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("SubscriptionId");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            SubscriptionId = 0,
                            StartDate = "05-01-2016",
                            SubPeriod = "Monthly",
                            SubscriptionName = "Netflix",
                            UnitPrice = 9.9900000000000002
                        },
                        new
                        {
                            SubscriptionId = 1,
                            StartDate = "07-29-2018",
                            SubPeriod = "Monthly",
                            SubscriptionName = "Hulu",
                            UnitPrice = 12.99
                        },
                        new
                        {
                            SubscriptionId = 2,
                            StartDate = "01-01-2022",
                            SubPeriod = "Annualy",
                            SubscriptionName = "PS PLUS",
                            UnitPrice = 120.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
