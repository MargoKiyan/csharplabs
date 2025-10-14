namespace HospitalManagementSystem;

public class Hospital
{
    public List<Doctor> Doctors;
    public List<Patient> Patients;
    public List<HospitalRoom> Rooms;
    public List<MedicalRecord> Records;
    public int totalPatientsInRooms;

    public Hospital()
    {
        Doctors = new List<Doctor>();
        Patients = new List<Patient>();
        Rooms = new List<HospitalRoom>();
        Records = new List<MedicalRecord>();
        totalPatientsInRooms = 0;
    }

    public void AddDoctor(Doctor doctor)
    {
        Doctors.Add(doctor);
        Console.WriteLine($"Лікар {doctor.Name} ({doctor.Specialization}) доданий до системи");
    }

    public void RegisterPatient(Patient patient)
    {
        Patients.Add(patient);
        Console.WriteLine($"Пацієнт {patient.Name}, {patient.Age} років, зареєстрований");
    }

    public void CreateRoom(HospitalRoom room)
    {
        Rooms.Add(room);
        Console.WriteLine($"Палата №{room.RoomNumber} створена (місткість: {room.Capacity})");
    }

    public void HospitalizePatient(int patientId, int roomNumber)
    {
        Patient patient = Patients.Find(Patient => Patient.Id == patientId);
        if (patient == null)
        {
            Console.WriteLine($"Пацієнт з ID {patientId} не знайдений!");
            return;
        }
        
        HospitalRoom room = Rooms.Find(Room => Room.RoomNumber == roomNumber);
        if (room == null)
        {
            Console.WriteLine($"Палата №{roomNumber} не знайдена!");
            return;
        }
        
        room.AddPatient(patient);
        totalPatientsInRooms++;
    }

    public void AddMedicalRecord(MedicalRecord medicalRecord)
    {
        Records.Add(medicalRecord);
        Console.WriteLine($"Медичний запис створено: {medicalRecord.Patient.Name} -> {medicalRecord.Doctor.Name}");
    }

    public List<MedicalRecord> GetPatientHistory(int patientId)
    {
        List<MedicalRecord> medicalRecords = Records.FindAll(medicalRecord => medicalRecord.Patient.Id == patientId);
        return medicalRecords;
    }

    public string GetStatistics()
    {
        return @$"=== СТАТИСТИКА ЛІКАРНІ ===
Кількість лікарів: {Doctors.Count}
Кількість зареєстрованих пацієнтів: {Patients.Count}
Кількість палат: {Rooms.Count}
Кількість пацієнтів у палатах: {totalPatientsInRooms}
Кількість медичних записів: {Records.Count}";
    }
}