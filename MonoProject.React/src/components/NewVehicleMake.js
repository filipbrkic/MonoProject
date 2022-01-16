import React, { useRef } from "react";
import { inject, observer } from "mobx-react";

const NewVehicleMake = ({ rootStore }) => {
    const nameInputRef = useRef(null);
    const abrvInputRef = useRef(null);

    const createVehicleMakeHandler = (() => {

        const enteredName = nameInputRef.current.value;
        const enteredAbrv = abrvInputRef.current.value;

        rootStore.vehicleMakeStore.createVehicleMakeAsync({
            id: null,
            name: enteredName,
            abrv: enteredAbrv,
        })
    });

    return (
        <form onSubmit={() => createVehicleMakeHandler()}>
            <div>
                <input id="name" type="text" placeholder="Name" ref={nameInputRef} />
            </div>
            <div>
                <input id="abrv" type="text" placeholder="Abbreviation" ref={abrvInputRef} />
            </div>
            <button type="submit" >Save</button>
        </form>
    );
}

export default inject("rootStore")(observer(NewVehicleMake));