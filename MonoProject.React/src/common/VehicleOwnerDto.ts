export class VehicleOwnerDto {
    id: number | null;
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    modelId: number | null;
    registrationId: number | null;
    registrationNumber: string;
    makeId: number | null;
    engineTypeId: number | null;
    name: string;
    abrv: string;
    constructor(id: number | null, firstName: string, lastName: string, dateOfBirth: Date, modelId: number | null,
        registrationId: number | null, registrationNumber: string, makeId: number | null, engineTypeId: number | null, name: string, abrv: string) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.modelId = modelId;
        this.registrationId = registrationId;
        this.registrationNumber = registrationNumber;
        this.makeId = makeId;
        this.engineTypeId = engineTypeId;
        this.name = name;
        this.abrv = abrv;
    }
}