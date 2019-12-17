//
//  ContentView.swift
//  SmartElevator WatchKit Extension
//
//  Created by Jacob Mokuvos on 12/17/19.
//  Copyright © 2019 Jacob Mokuvos. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    
    let number = Int.random(in: 20 ... 70)
    
    var body: some View {
        VStack {
            Text("Going to")
                .font(.system(size: 30, design: .rounded))
                .foregroundColor(.blue)
                .multilineTextAlignment(.leading)
            
            Text("Floor \(number)?")
            .font(.system(size: 30, design: .rounded))
                .foregroundColor(.blue)
                .multilineTextAlignment(.leading)
            
                
                
            NavigationLink(destination:
                ElevatorAssignmentView()
            ) {
                Text("Yes")
            }
            
            Button(action: /*@START_MENU_TOKEN@*/{}/*@END_MENU_TOKEN@*/) {
                Text("No")
            }
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
