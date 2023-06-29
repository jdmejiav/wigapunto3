import { IonContent, IonHeader, IonPage, IonTitle, IonToolbar } from '@ionic/react';
import UserListComponent from '../components/UserListComponent';
import './Home.css';

const Home: React.FC = () => {
  return (
    <IonPage>
      <IonHeader>
        <IonToolbar>
          <IonTitle>Clientes</IonTitle>
        </IonToolbar>
      </IonHeader>
      <IonContent fullscreen>
        <IonHeader collapse="condense">
          <IonToolbar>
            <IonTitle size="large">Blank</IonTitle>
          </IonToolbar>
        </IonHeader>
        <UserListComponent />
      </IonContent>
    </IonPage>
  );
};

export default Home;
