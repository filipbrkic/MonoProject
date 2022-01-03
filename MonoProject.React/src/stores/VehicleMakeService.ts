import { VehicleMakeDto } from "../common/VehicleMakeDto";

export const post = async (model: VehicleMakeDto) => {
    try {
        const response = await fetch("http://localhost:51044/VehicleMake/PostVehicleMake", {
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
        const response = await fetch("http://localhost:51044/VehicleMake/GetAllVehicleMake", {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        })
        return await response.json();
    } catch (error) {
        console.log(error)
    }
}