import React from 'react';
import {
  StyleSheet,
  View,
  ScrollView,
  Button
} from 'react-native';
import Header from './Header';
import User from './User';

const UerWrapper = ({navigation}) => {

  const users = [
    {
      "id":1,
      "firstName": "Konstance",
      "lastName": "Emmy",
      "city": "Konya",
      "country": "Guinea",
      "GDP": 11000
    },
    {
      "id":2,
      "firstName": "Amara",
      "lastName": "Gabrielli",
      "city": "Alexandria",
      "country": "Saint Lucia",
      "GDP": 9500
    },
    {
      "id":3,
      "firstName": "Dorothy",
      "lastName": "Boycey",
      "city": "Kunming",
      "country": "Niue",
      "GDP": 10000
    },
    {
      "id":4,
      "firstName": "Dania",
      "lastName": "Primalia",
      "city": "Apia",
      "country": "Afghanistan",
      "GDP": 11300
    },
    {
      "id":5,
      "firstName": "Tamqrah",
      "lastName": "Sparhawk",
      "city": "Paramaribo",
      "country": "Grenada",
      "GDP": 12000
    },
    {
      "id":6,
      "firstName": "Britni",
      "lastName": "Posner",
      "city": "Accra",
      "country": "Togo",
      "GDP": 11000
    },
    {
      "id":7,
      "firstName": "Jorry",
      "lastName": "Monaco",
      "city": "Hiroshima",
      "country": "Martinique",
      "GDP": 8500
    },
    {
      "id":8,
      "firstName": "Mireielle",
      "lastName": "Elsinore",
      "city": "New York City",
      "country": "Swaziland",
      "GDP": 8000
    },
    {
      "id":9,
      "firstName": "Tina",
      "lastName": "Edvard",
      "city": "Belgrade",
      "country": "Burundi",
      "GDP": 9000
    },
    {
      "id":10,
      "firstName": "Margette",
      "lastName": "Martguerita",
      "city": "Gaza",
      "country": "Bulgaria",
      "GDP": 8000
    },
    {
      "id":11,
      "firstName": "Mignon",
      "lastName": "Bennie",
      "city": "Ibiza",
      "country": "Korea, Democratic People\"S Republic of",
      "GDP": 14000
    }
  ]

  return (
    <View style={styles.container}>
        <Button title='Đi tới UserList' onPress={() => navigation.navigate("UserList")}></Button>
      <Header/>
      <ScrollView>
        {
          users.map((u) => <User item={u}/>)
        }
      </ScrollView>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff'
  }
});

export default UerWrapper;
