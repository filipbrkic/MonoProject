export const post = async (model) => {
    const response = await fetch("http://localhost:51044/VehicleMake/PostVehicleMake", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
        },
        body: JSON.stringify(model),
    });
    try {
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
            },
        })
        return await response.json();
    } catch (error) {
        console.log(error)
    }
}

