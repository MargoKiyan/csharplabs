namespace HospitalManagementSystem;

public class HospitalDemo
{
    public void Run()
    {
        Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");
    
        Hospital hospital = new Hospital();
    
        hospital.AddDoctor(new Doctor(1, "Маргарита Киян", "Хірург"));
        hospital.AddDoctor(new Doctor(2, "Терьохін Мирослав", "Венеролог"));
        hospital.AddDoctor(new Doctor(3, "Солдатов Андрій", "Психіатр"));
    
        hospital.RegisterPatient(new Patient(1, "Стетий Максим", 18));
        hospital.RegisterPatient(new Patient(2, "Перчук Олександр", 24));
        hospital.RegisterPatient(new Patient(3, "Колчанов Владислав", 19));
        hospital.RegisterPatient(new Patient(4, "Торвальдс Лінус", 55));
    
        hospital.CreateRoom(new HospitalRoom(1, 2));
        hospital.CreateRoom(new HospitalRoom(2, 1));
    
        hospital.HospitalizePatient(1, 1);
        hospital.HospitalizePatient(2, 1);
        hospital.HospitalizePatient(3, 2);
        hospital.HospitalizePatient(4, 2);
    
        hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[0], hospital.Doctors[0], DateTime.Now, "Перелом правої ноги"));
        hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[1], hospital.Doctors[1], DateTime.Now, "Ознаки СНІД"));
        hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[2], hospital.Doctors[2], DateTime.Now, "Ознаки депресивного розладу"));
        hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[3], hospital.Doctors[0], DateTime.Now, "Перелом лівого зап'ястку"));
    
        // Історія пацієнта
        Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");
        var history = hospital.GetPatientHistory(1);
        foreach (var record in history)
        {
            Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
            Console.WriteLine($"  Лікар: {record.Doctor.Name}");
            Console.WriteLine($"  Опис: {record.Description}\n");
        }
    
        // Статистика
        Console.WriteLine(hospital.GetStatistics());
    }

}