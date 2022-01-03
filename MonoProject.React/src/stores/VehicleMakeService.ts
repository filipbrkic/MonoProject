import { VehicleMakeDto } from "../common/VehicleMakeDto";

const post = async (model: VehicleMakeDto) => {
    try {
        const response = await fetch("http://localhost:51044/VehicleMake/PostVehicleMake", {
            method: "POST",
            body: JSON.stringify(model),
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
            },
        });
        return response;
    } catch (error) {
        console.log(error)
    }
}

export default post;