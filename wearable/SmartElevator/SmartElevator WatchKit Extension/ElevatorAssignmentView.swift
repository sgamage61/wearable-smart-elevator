//
//  ElevatorAssignmentView.swift
//  SmartElevator WatchKit Extension
//
//  Created by Jacob Mokuvos on 12/17/19.
//  Copyright © 2019 Jacob Mokuvos. All rights reserved.
//

import SwiftUI

















let num = Int.random(in: 1 ... 8)

struct ElevatorAssignmentView: View {
    var body: some View {
        Text("Proceed to Elevator \(num)B")
            .font(.largeTitle)
            .foregroundColor(.blue)
            .multilineTextAlignment(.center)
    }
}

struct ElevatorAssignmentView_Previews: PreviewProvider {
    static var previews: some View {
        ElevatorAssignmentView()
    }
}
