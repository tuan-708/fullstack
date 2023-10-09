import React, {useState} from 'react';
import { View, Text,  } from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import AsyncStorage from '@react-native-async-storage/async-storage';

const Tab = createBottomTabNavigator();

function InfoScreen({ route }) {
  const { email } = route.params;
  const [getName, setName] = useState('');
  AsyncStorage.getItem('name').then(value => {
    if(value != null){
      setName(value);
    }
  })
  
  return (
    <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
      
      <Text>Infor user {email}</Text>

      <Text>Infor user {getName}</Text>
    </View>
  );
}

function SettingScreen() {
  return (
    <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
      <Text>Settings!</Text>
    </View>
  );
}

function HomeScreen( { route, navigation }) {
  const { email } = route.params;

  return (
    <Tab.Navigator>
      <Tab.Screen name="Home" component={InfoScreen} initialParams={{ email: email }}  options={{headerShown: false}}/>
      <Tab.Screen name="Settings" component={SettingScreen} options={{headerShown: false}}/>
    </Tab.Navigator>
  );
}

export default HomeScreen;