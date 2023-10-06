import * as React from 'react';
import { Button, View, Text } from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import App from '../../App';
import { useRoute } from '@react-navigation/native';

const Tab = createBottomTabNavigator();

function InfoScreen({ route }) {
  const { email } = route.params;
  
  return (
    <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
      
      <Text>Infor user {email}</Text>
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