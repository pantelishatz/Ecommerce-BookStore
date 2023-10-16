using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorEcommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Το μοναδικό ανέκδοτο έργο του Νίκου Καζαντζάκη. Ο μεγάλος Έλληνας λογοτέχνης γράφει με ένταση και αγωνία υπαρξιακή, αναλογιζόμενος όλα τα μεγάλα ερωτήματα, που ταλανίζουν τους ανθρώπους μέχρι και σήμερα.", "https://www.dioptra.gr/Cache/Photos/ac6a19676b8a98d09ab782bc15660274.png", 19.99m, "Ο Ανήφορος" },
                    { 2, "Το μεγαλύτερο θαύμα στον κόσμο προσφέρει μια ανεκτίμητη σοφία σε όσους ψάχνουν για ένα ανώτερο μήνυμα και σκοπό στη ζωή τους. Το νέο best seller του Ογκ Μαντίνο είναι μια μαγευτική αφήγηση που αποκαλύπτει εντυπωσιακά μυστικά για προσωπική ευτυχία και επαγγελματική επιτυχία, και περιλαμβάνει ένα διαχρονικό μήνυμα… Ανακαλύψτε τον Σάιμον Πότερ, έναν καταπληκτικό ρακοσυλλέκτη, που σώζει ανθρώπους που έχουν απελπιστεί από τη ζωή και μάθετε τους τέσσερις απλούς κανόνες που θα σας επιτρέψουν να πραγματοποιήσετε ένα θαύμα στη δική σας ζωή.", "https://www.dioptra.gr/Cache/Photos/5aa101be928429da388563300ace701d.png", 20.00m, "Το μεγαλύτερο θαύμα στον κόσμο" },
                    { 3, "Ένα απρόσμενο λάθος από τις Μοίρες αλλάζει τη ζωή ενός κοριτσιού. Κινούμενου στο χώρο του μαγικού ρεαλισμού και της και της φανταστικής λογοτεχνίας, το βιβλίο συνυφαίνει την πορεία της ηρωίδας με τη δύναμη του πεπρωμένου. Στην πλοκή στροβιλίζονται η σκληρότητα του πατέρα, οι δισταγμοί της μάνας, η εχθρότητα ενός χωριού και ο έρωτας της κόρης. Μπορεί κανείς άραγε ν` αλλάξει τη μοίρα του", "https://www.lavyrinthos.net/images/products/ext/osd_1094481.jpg", 17.99m, "Τα πράσινα, τα καστανά και τα μαύρα μάτια!" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
