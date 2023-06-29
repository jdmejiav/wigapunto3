import { IonContent, IonHeader, IonPage, IonTitle, IonToolbar } from '@ionic/react';
import FacturasListComponent from '../components/FacturasListComponent';
import './Home.css';


const Facturas: React.FC = () => {
    
    return (
        <IonPage>
            <IonHeader>
                <IonToolbar>
                    <IonTitle>Facturas </IonTitle>
                </IonToolbar>
            </IonHeader>
            <IonContent fullscreen>
                <IonHeader collapse="condense">
                    <IonToolbar>
                        <IonTitle size="large">Blank</IonTitle>
                    </IonToolbar>
                </IonHeader>

                <FacturasListComponent />
            </IonContent>
        </IonPage>
    );
};

export default Facturas;
