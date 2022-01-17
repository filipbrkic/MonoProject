import { VehicleOwnerDto } from "../common/VehicleOwnerDto";

export const post = async (model: VehicleOwnerDto) => {
    try {
        const response = await fetch("http://localhost:51044/VehicleOwner/PostVehicleModelOwner", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
            },
            body: JSON.stringify(model),
        });
        return response;
    } catch (error) {
        console.log(error)
    }
}

export const getAll = async () => {
    try {
        const response = await fetch("http://localhost:51044/VehicleOwner/GetAllVehicleOwner", {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            },
        })
        return await response.json();
    } catch (error) {
        console.log(error)
    }
}