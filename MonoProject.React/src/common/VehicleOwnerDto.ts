export class VehicleOwnerDto {
    id: number | null;
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    constructor(id: number | null, firstName: string, lastName: string, dateOfBirth: Date,) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
    }
}