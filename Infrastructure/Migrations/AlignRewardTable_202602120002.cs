using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(202602120002)]
public class AlignRewardTable_202602120002 : Migration
{
    public override void Up()
    {
        Alter.Table("Reward")
            .AddColumn("RewardGiver").AsString(200).Nullable()
            .AddColumn("RewardAmount").AsString(50).Nullable()
            .AddColumn("RewardReason").AsString(500).Nullable()
            .AddColumn("OrderType").AsString(100).Nullable()
            .AddColumn("FilePath").AsString(int.MaxValue).Nullable();

        // Optional: Clean up unused columns if strictly following model
        // Delete.Column("RewardName").FromTable("Reward");
        // Delete.Column("RewardDate").FromTable("Reward");
        // Delete.Column("Notes").FromTable("Reward");
    }

    public override void Down()
    {
        Delete.Column("FilePath").FromTable("Reward");
        Delete.Column("OrderType").FromTable("Reward");
        Delete.Column("RewardReason").FromTable("Reward");
        Delete.Column("RewardAmount").FromTable("Reward");
        Delete.Column("RewardGiver").FromTable("Reward");
        
        // Restore if deleted
        // Alter.Table("Reward").AddColumn("RewardName").AsString(500).Nullable();
        // Alter.Table("Reward").AddColumn("RewardDate").AsDateTime().Nullable();
        // Alter.Table("Reward").AddColumn("Notes").AsString(int.MaxValue).Nullable();
    }
}
