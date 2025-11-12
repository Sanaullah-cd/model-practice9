using System;

public class RoomBookingSystem
{
    public void BookRoom(string guestName)
    {
        Console.WriteLine($"Room booked for {guestName}.");
    }

    public void CancelBooking(string guestName)
    {
        Console.WriteLine($"Booking cancelled for {guestName}.");
    }
}

public class RestaurantSystem
{
    public void BookTable(string guestName)
    {
        Console.WriteLine($"Table booked for {guestName} at the restaurant.");
    }

    public void OrderFood(string guestName, string dish)
    {
        Console.WriteLine($"{guestName} ordered {dish}.");
    }
}

public class EventManagementSystem
{
    public void BookHall(string eventName)
    {
        Console.WriteLine($"Conference hall booked for event: {eventName}.");
    }

    public void RentEquipment(string equipment)
    {
        Console.WriteLine($"{equipment} rented for the event.");
    }
}

public class CleaningService
{
    public void ScheduleCleaning(string room)
    {
        Console.WriteLine($"Cleaning scheduled for room: {room}.");
    }

    public void PerformCleaning(string room)
    {
        Console.WriteLine($"Cleaning completed for room: {room}.");
    }
}

public class HotelFacade
{
    private RoomBookingSystem _roomBooking;
    private RestaurantSystem _restaurant;
    private EventManagementSystem _eventSystem;
    private CleaningService _cleaning;

    public HotelFacade(RoomBookingSystem room, RestaurantSystem restaurant, EventManagementSystem eventSys, CleaningService cleaning)
    {
        _roomBooking = room;
        _restaurant = restaurant;
        _eventSystem = eventSys;
        _cleaning = cleaning;
    }

    // Book room with restaurant & cleaning services
    public void BookRoomWithServices(string guestName, string dish)
    {
        Console.WriteLine("\n--- Booking Room with Restaurant & Cleaning Services ---");
        _roomBooking.BookRoom(guestName);
        _restaurant.BookTable(guestName);
        _restaurant.OrderFood(guestName, dish);
        _cleaning.ScheduleCleaning("Room 101");
        Console.WriteLine("All services booked successfully.\n");
    }

    // Organize event
    public void OrganizeEvent(string eventName)
    {
        Console.WriteLine("\n--- Organizing Event ---");
        _eventSystem.BookHall(eventName);
        _eventSystem.RentEquipment("Projector");
        _roomBooking.BookRoom("Event Guests");
        Console.WriteLine("Event organized successfully.\n");
    }

    // Book table and call taxi
    public void BookRestaurantWithTaxi(string guestName)
    {
        Console.WriteLine("\n--- Restaurant Reservation with Taxi ---");
        _restaurant.BookTable(guestName);
        Console.WriteLine($"Taxi ordered for {guestName}.");
    }

    // Cancel booking
    public void CancelRoomBooking(string guestName)
    {
        Console.WriteLine("\n--- Cancel Booking ---");
        _roomBooking.CancelBooking(guestName);
        Console.WriteLine("Cancellation completed.\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var room = new RoomBookingSystem();
        var restaurant = new RestaurantSystem();
        var eventSystem = new EventManagementSystem();
        var cleaning = new CleaningService();

        var hotelFacade = new HotelFacade(room, restaurant, eventSystem, cleaning);

        hotelFacade.BookRoomWithServices("John Doe", "Steak");
        hotelFacade.OrganizeEvent("Tech Conference 2025");
        hotelFacade.BookRestaurantWithTaxi("Alice");
        hotelFacade.CancelRoomBooking("John Doe");
    }
}
