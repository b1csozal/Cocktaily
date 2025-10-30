import { SafeAreaView } from "react-native-safe-area-context";
import { Text, StyleSheet } from "react-native";
import React from "react";

const TabsSearch = () => {
  return (
    <SafeAreaView style={styles.container}>
        <Text>Tabs Search</Text>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
    },
});

export default TabsSearch;