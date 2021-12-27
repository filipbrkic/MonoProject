import { VehicleMakeDto } from "../common/VehicleMakeDto";

const webApiUrl = "http://localhost:51044/VehicleMake";

const VehicleMakeService: any = () => {
    const post = async (model: VehicleMakeDto) => {
        const headers = new Headers();
        headers.append("Content-Type", "application/json");
        var options = {
            method: "POST",
            headers,
            body: JSON.stringify(model)
        }
        const request = new Request(webApiUrl, options);
        const response = await fetch(request);
        return response;
    }
};

export default VehicleMakeService;