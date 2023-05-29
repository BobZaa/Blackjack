namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blackjack!");

            // Create a deck of cards
            Deck deck = new Deck();

            // Shuffle the deck
            deck.Shuffle();

            // Deal two cards to the player
            Hand playerHand = new Hand();
            playerHand.AddCard(deck.DealCard());
            playerHand.AddCard(deck.DealCard());

            // Deal two cards to the dealer
            Hand dealerHand = new Hand();
            dealerHand.AddCard(deck.DealCard());
            dealerHand.AddCard(deck.DealCard());

            // Show the initial hands
            Console.WriteLine("Dealer's hand:");
            dealerHand.Draw();
            Console.WriteLine("Player's hand:");
            playerHand.Draw();

            // Player's turn
            while (true)
            {
                Console.Write("Hit or stand? ");
                string input = Console.ReadLine();

                if (input.ToLower() == "hit" || input.ToLower() == "h")
                {
                    // Deal another card to the player
                    playerHand.AddCard(deck.DealCard());
                    playerHand.Draw();

                    // Check if the player busted
                    if (playerHand.GetScore() > 21)
                    {
                        Console.WriteLine("You busted! Dealer wins.");
                        return;
                    }
                }
                else if (input.ToLower() == "stand" || input.ToLower() == "s")
                {
                    // End the player's turn
                    break;
                }
            }
            // Dealer's turn
            Console.WriteLine("Dealer's turn:");
                dealerHand.Draw();

                while (dealerHand.GetScore() < 17)
                {
                    // Deal another card to the dealer
                    dealerHand.AddCard(deck.DealCard());
                    dealerHand.Draw();

                    // Check if the dealer busted
                    if (dealerHand.GetScore() > 21)
                    {
                        Console.WriteLine("Dealer busted! You win!");
                        return;
                    }
                }

                // Compare scores
                int playerScore = playerHand.GetScore();
                int dealerScore = dealerHand.GetScore();

                if (playerScore > dealerScore)
                {
                    Console.WriteLine("You win!");
                }
                else if (playerScore == dealerScore)
                {
                    Console.WriteLine("It's a tie!");
                }
                else
                {
                    Console.WriteLine("Dealer wins!");
                }
            }
        }
    }