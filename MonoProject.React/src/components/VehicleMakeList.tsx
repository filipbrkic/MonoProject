import React, { useState } from "react";
import { inject, observer } from "mobx-react";
import { Key, ReactChild, ReactFragment, ReactPortal, useEffect } from "react";
import { autorun } from "mobx";
import Modal from "react-modal";
import UpdateVehicleMake from "./UpdateVehicleMake";
import classes from "./VehicleMakeList.module.css"

const VehicleMakeList: React.FC = ({ rootStore }: any) => {
    useEffect(() => autorun(() => {
        rootStore.vehicleMakeStore?.getAllVehicleMakeAsync();
    }), [])

    const [modalIsOpen, setIsOpen] = useState(false);

    function openModal() {
        setIsOpen(true);
    }

    function closeModal() {
        setIsOpen(false);
    }

    return (
        <div className={classes.table}>
            <h1>List of Vehicle Brands</h1>
            <table>
                <thead>
                    <tr>
                        <th>
                            Name
                        </th>
                        <th>
                            Abrv
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {rootStore.vehicleMakeStore.data.map((make: { id: Key | null | number; name: boolean | ReactChild | ReactFragment | ReactPortal | null | string; abrv: boolean | ReactChild | ReactFragment | ReactPortal | null | string; }) =>
                        <tr key={make.id}>
                            <td>{make.name}</td>
                            <td>{make.abrv}</td>
                            <td>
                                <button onClick={openModal}>Edit</button>

                                <Modal
                                    isOpen={modalIsOpen}
                                    className={classes.modal}
                                    ariaHideApp={false}
                                    contentLabel="Update Modal"
                                >
                                    <div>
                                        <UpdateVehicleMake makeId={make.id} />
                                        <div className={classes.close}>

                                            <button onClick={closeModal} >close</button>
                                        </div>
                                    </div>
                                </Modal>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div >
    )
};



export default inject("rootStore")(observer(VehicleMakeList))