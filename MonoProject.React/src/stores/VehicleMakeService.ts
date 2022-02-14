import { VehicleMakeDto } from "../common/VehicleMakeDto";

class VehicleMakeService {
    post = async (model: VehicleMakeDto) => {
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

    getAll = async () => {
        try {
            const response = await fetch("http://localhost:51044/VehicleMake/GetAllVehicleMake", {
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

    update = async (model: VehicleMakeDto) => {
        try {
            const response = await fetch("http://localhost:51044/VehicleMake/UpdateVehicleMake", {
                method: "PUT",
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

    delete = async (id: number) => {
        try {
            const response = await fetch(`http://localhost:51044/VehicleMake/DeleteVehicleMake?id=${id}`, {
                method: "DELETE",
                headers: {
                    "Content-Type": "application/json"
                },
            })
            return response;
        } catch (error) {
            console.log(error)
        }
    }
}

export default VehicleMakeService;